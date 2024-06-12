﻿namespace SpiderWatcher_Client.DTOs.UserDTO
{
    public class ValidateUserDTO
    {
        public string UpdateType { get; set; }
        public int IdUser { get; set; }
        public string Password { get; set; }
        public bool? Restore { get; set; }
        public string ValidationMessage { get; set; }
        public string UserName { get; set; }
        public bool? AccountType { get; set; }
    }
}
