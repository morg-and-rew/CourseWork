namespace CourseWork.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int GameID { get; set; }
        public uint Price { get; set; }
        public virtual Game Game { get; set; }
        public virtual Order Order { get; set; }
    }
}
