namespace GradAndInternship.Models;

public class Document
{
    public Guid Id { set; get; }
    public string Title { set; get; }
    public string Status { set; get; }
    public DateTime UploadedAt { set; get; }
    public string PathDocument { set; get; }
    public string UrlDocument{ set; get; }
    public string CommentFromDoctor { set; get; }

   public Guid StudentId { get; set; }
   public Student Student { set; get; }

}