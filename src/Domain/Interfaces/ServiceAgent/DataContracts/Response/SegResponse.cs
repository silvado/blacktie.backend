namespace Domain.Interfaces.ServiceAgent.DataContracts.Response
{
    public class SegResponse
    {
        public List<SegSistema>? Sistemas { get; set; }        
    }

    public class SegSistema 
    {
        public int CodSistema { get; set; }
        public string? SiglaSistema { get; set; }
        public string? NomeSist { get; set; }
    }
}
