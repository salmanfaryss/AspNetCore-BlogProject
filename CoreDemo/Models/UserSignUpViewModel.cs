using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen ad ve soyad giriniz")]
        public string namesurname { get; set; }


        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }


        [Display(Name = "Mail adresi")]
        [Required(ErrorMessage = "Lütfen mail adresiniz girin")]
        public string Email { get; set; }

        [Display(Name = "Kullanıcı adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı giriniz")]
        public string UserName { get; set; }
    }
}
