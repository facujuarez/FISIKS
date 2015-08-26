using FisiksAppWeb.Util;

namespace FisiksAppWeb.Entities
{
    public class TestDetalleDto : DtoBase
    {
        public int DetId { get; set; }
        public int DetTstId { get; set; }

        public TestDetalleDto(int detId, int detTstId)
        {
            DetId = detId;
            DetTstId = detTstId;
            IsNew = true;
        }

        public TestDetalleDto()
        {
        }
    }
}
