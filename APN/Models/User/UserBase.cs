using System;

namespace APN.Models.User
{
    public class UserBase
    {
        UInt64? id { get; set; }
        string Name { get; set; }
        string Alias { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Cellphone { get; set; }
        string Address { get; set; }
        string Address2 { get; set; }
        string Address3 { get; set; }
        string City { get; set; }
        string County { get; set; }
        string Country { get; set; }
        string PostalCode { get; set; }
        string Observations { get; set; }
        string MapCoordinates { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        bool Active { get; set; }
        bool Locked { get; set; }
        bool Deleted { get; set; }
        DateTime LastLogin { get; set; }
        int LoginAttempts { get; set; }
        int AddedBy { get; set; }
        DateTime AddedAt { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedAt { get; set; }
    }
}
