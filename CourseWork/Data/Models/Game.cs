﻿namespace CourseWork.Data.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool IsFavorite {  get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
