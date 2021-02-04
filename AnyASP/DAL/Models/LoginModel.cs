using System.ComponentModel.DataAnnotations;

namespace AnyASP.Models
{
    public class LoginModel
    {
		[Required(ErrorMessage = "Не указан Email")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Не указан пароль")]
		public string Password { get; set; }
        public int wsid { get; set; }
        public int prid { get; set; }
        public string br_shift { get; set; }
        public string CurResource { get; set; }
        public string monitor { get; set; }
        public bool CreateBrigade { get; set; }
    }
}
