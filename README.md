# Wherewolf
A small library for encapsulating data queries through IoC.

Query parameters are passed through constructor and IoC is used to populate the arguments of the `Execute` method.

Example of using a query through the `IQueryExecutor`:

```csharp
bool usDuplicate = _queryExecutor.Execute(new QueryCodeEntryDuplicate(sourceQuestionIds));
```

Example of a query class - in this case specific to :

```csharp
public class QueryCodeEntryDuplicate : NHibernateQuery<bool>
{
    private readonly Guid _surveyId;
    private readonly string _codeListLabel;
    private readonly string _matchText;

    public QueryCodeEntryDuplicate(Guid surveyId, string codeListLabel, string matchText)
    {
        _surveyId = surveyId;
        _codeListLabel = codeListLabel;
        _matchText = matchText;
    }

    public override bool Execute(ISession session)
    {
        return session.Query<CodeEntry>()
            .Any(x => x.SurveyId == _surveyId
                && x.CodeListLabel == _codeListLabel
                && x.MatchText == _matchText);
    }
}
```
