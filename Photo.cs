using System.ComponentModel.DataAnnotations.Schema;

namespace n_json_schema_getting_started
{
    public class Photo: Entity
    {
        [ForeignKey("PhotoGallery")]
        public int? PhotoGalleryId { get; set; }
    }
}
