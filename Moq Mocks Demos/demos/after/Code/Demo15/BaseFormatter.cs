namespace PluralSight.Moq.Code.Demo15
{
    public abstract class BaseFormatter
    {
        public virtual string ParseBadWordsFrom(string value)
        {
            return value.Replace("SAP", string.Empty);
        }
    }
}