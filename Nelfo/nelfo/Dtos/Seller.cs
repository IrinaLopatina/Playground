namespace nelfo.Dtos
{
    public class Seller
    {
        public string? OrgNo { get; }
        public string? OrgName { get; }

        public Seller(string? orgNo, string? orgName)
        {
            OrgNo = orgNo;
            OrgName = orgName;
        }
    }
}
