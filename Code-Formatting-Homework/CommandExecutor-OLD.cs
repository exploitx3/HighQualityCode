using System;
using System.Linq;
using Blobs.Core.Commands;
using Blobs.Core.Exceptions;
using Blobs.Interfaces;
using Blobs.Models;
using Blobs.Models.Behaviors;

namespace Blobs.Core
{
    public class CommandExecutor : ICommandExecutor
    {
        public virtual void ExecuteCommand(string commandName, string[] inputParams, IDatabase db, IConsoleIOHandler consoleHandler)
        {
            ICommand command = null;
            switch (commandName)
            {
                case "report-events":
                        Blob.VerboseReport = true;
                    return;
                case "create":
                    string name = inputParams[0];
                    int health = int.Parse(inputParams[1]);
                    int damage = int.Parse(inputParams[2]);
                    string behaviorName = inputParams[3];
                    string attackName = inputParams[4];
                    
                    command = new CreateCommand(name, health, damage, behaviorName, attackName, db);
                    break;
                case "attack":
                    string attackerName = inputParams[0];
                    string targetName = inputParams[1];
                    IBlob attackerBlob = db.Blobs.FirstOrDefault(b => b.Name == attackerName);
                    if (attackerBlob == null)
                    {
                        throw new BlobsNullException("AttackerName","Invalid attacker name");
                    }
                    IBlob targetBlob = db.Blobs.FirstOrDefault(b => b.Name == targetName);
                    if (targetBlob == null)
                    {
                        throw new BlobsNullException("TargetName", "Invalid target name");
                    }
                    command = new AttackCommand(attackerBlob, targetBlob, db);
                    break;
                case "status":
                    command = new StatusCommand(db, consoleHandler);
                    break;
                case "pass":
                    return;
                default:
                    throw new NotImplementedException("The input command name is not implemented yet");
            }
            command.Execute();
        }
    }
}