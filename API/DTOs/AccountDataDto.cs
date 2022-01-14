namespace API.DTOs
{
    public class AccountDataDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override bool Equals(object obj)
        {
            var objToCompapre=(AccountDataDto)obj;
            if(!Username.Equals(objToCompapre.Username))return false;
            if(!Email.Equals(objToCompapre.Email))return false;
            if(!FirstName.Equals(objToCompapre.FirstName))return false;
            if(!LastName.Equals(objToCompapre.LastName))return false;
            return true;
        }
    }
}