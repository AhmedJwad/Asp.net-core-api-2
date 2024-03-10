namespace Asp.net_core_api.Model
{
    public class PassengerModel
    {
        public int Pass_ID { get; set; }
        public long Pass_PhoneNumber { get; set; }
        public string Pass_Password { get; set; }
        public string Pass_FristName { get; set; }
        public string Pass_SecondName { get; set; }
        public string Pass_LastName { get; set; }
        public int? Pass_GenderM { get; set; }
        public DateTime? Pass_BirthDate { get; set; }
        public short? Pass_Rank { get; set; }
        public byte? Pass_Rating { get; set; }
        public int? Pass_Balance { get; set; }
        public short Pass_Flags { get; set; }
        public byte Pass_Status { get; set; }
        public byte Pass_languge { get; set; }
        public DateTime? email_verified_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? created_at { get; set; }
    }
}
