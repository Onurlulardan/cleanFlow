namespace cleanFlow.Dtos.WorkorderDtos
{
    public class ResultWorkOrderDto
    {
        public int WORKORDERID { get; set; }

        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string LOCATIONNAME { get; set; }
        public DateTime CREATED_AT { get; set; }
        public DateTime SHIFTSTARTDATE { get; set; }
        public DateTime SHIFTENDDATE { get; set; }
    }
}
