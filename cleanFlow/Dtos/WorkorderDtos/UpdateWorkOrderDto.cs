namespace cleanFlow.Dtos.WorkorderDtos
{
    public class UpdateWorkOrderDto
    {
        public int ASSIGNID { get; set; }
        public int SHIFTID { get; set; }
        public int PERSONELID { get; set; }
        public IFormFile? LAVABO_PHOTO { get; set; }
        public IFormFile? PISUAR_PHOTO { get; set; }
        public IFormFile? KLOZET_PHOTO { get; set; }
        public IFormFile? TEZGAH_PHOTO { get; set; }
        public IFormFile? SABUNLUK_PHOTO { get; set; }
        public IFormFile? KABIN_PHOTO { get; set; }
        public IFormFile? AYNA_PHOTO { get; set; }
        public IFormFile? COP_PHOTO { get; set; }
        public IFormFile? TUVALET_KAGIDI_PHOTO { get; set; }
        public IFormFile? HAVLU_MAKINESI_PHOTO { get; set; }
    }
}
