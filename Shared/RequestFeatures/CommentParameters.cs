namespace ForumApp.Shared.RequestFeatures;

public class CommentParameters : RequestParameters
{
    public DateTime MinDate { get; set; }
    public DateTime MaxDate { get; set; }

    public bool ValidAgeRange => MaxDate > MinDate;
}
