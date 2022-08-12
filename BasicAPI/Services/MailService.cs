using BasicAPI.Interfaces;
using BasicAPI.Models.Data;

namespace BasicAPI.Services
{
    public class MailService : IMailService
    {
        private readonly CidenetDBContext _db;

        public MailService(CidenetDBContext db)
        {
            _db = db;
        }
        public string CreateMail(string firstName, string surname, string country)
        {
            string domm = country.Equals("Colombia") ? "@cidenet.com.co" : "@cidenet.com.us";

            string name1 = $"{firstName}.{surname = surname.Replace(" ",String.Empty)}";
            var mailCount = _db.Funcionarios.Select(x=> x.Correo.Equals($"{name1}{domm}")).Count();

            string mail = mailCount == 0 ? $"{name1}{domm}" : $"{name1}.{mailCount}{domm}";

            return mail;
        }
    }
}
