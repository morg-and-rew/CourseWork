using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [Display(Name = "Введите имя")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Имя должно быть от 5 до 50 символов")]
        [Required(ErrorMessage = "Имя обязательно для заполнения")]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Фамилия должна быть от 5 до 50 символов")]
        [Required(ErrorMessage = "Фамилия обязательна для заполнения")]
        public string Surname { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Адрес должен быть от 5 до 100 символов")]
        [Required(ErrorMessage = "Адрес обязателен для заполнения")]
        public string Adress { get; set; }

        [Display(Name = "Номер телефона")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Телефон должен быть от 10 до 15 символов")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Телефон обязателен для заполнения")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(255, MinimumLength = 15, ErrorMessage = "Длина email должна быть от 15 до 255 символов")]
        [Required(ErrorMessage = "Email обязателен для заполнения")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}