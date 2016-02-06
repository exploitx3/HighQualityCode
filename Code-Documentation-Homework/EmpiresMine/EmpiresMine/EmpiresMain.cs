using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpiresMine.Core;
using EmpiresMine.Interfaces;

namespace EmpiresMine
{
    class EmpiresMain
    {
        static void Main(string[] args)
        {
            IDatabase database = new Database();
            ICommandDispacher commandDispacher = new CommandDispacher(database);

            IEngine engine = new Engine(database,commandDispacher);
            engine.Run();
        }
    }
}
