namespace FunderService.Mappers
{
    using AzureFunderCommonMessages.DotNet.Types.ValueConstants;
    using FunderTitle =  FunderApi.Title;
    using Title = AzureFunderCommonMessages.DotNet.Types.ValueConstants.Title;

    public static class TitleMapper
    {
        public static FunderTitle Map(string title)
        {
            return title switch
            {
                Title.Mr =>  FunderTitle.Mr,
                Title.Miss => FunderTitle.Miss,
                Title.Mrs => FunderTitle.Mrs,
                Title.Ms => FunderTitle.Ms,
                Title.Dr => FunderTitle.Dr,
                Title.Rev => FunderTitle.Rev,
                _ => FunderTitle.Mr
            };
        }
    }
}