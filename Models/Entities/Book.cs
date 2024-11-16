namespace MAchineTest.Models.Entities
{
    public class Book
    {
      public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }

        public int Publitionyear {  get; set; }
        public int Authorid { get; set; }
        public int  Categoryid { get; set; }
   

    }
}
