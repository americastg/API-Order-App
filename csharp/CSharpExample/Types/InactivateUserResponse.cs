namespace ATG.API.Types
{
    public class InactivateUserResponse
    {
        /// <summary>
        /// Inactivated user
        /// </summary>
        public string UserInactivated { get; set; }

        /// <summary>
        /// Whether the request was successfully executed. If false, the Error field will be filled.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// If it fails, the error will come in this field
        /// </summary>
        public string Error { get; set; }
    }
}
