using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;

namespace BCUniversity.Infrastructure.DataModel
{
    [Table("theatre")]
    public class TheatreDataModel: EntityDataModelBase
    {
        public string Name { get; private set; }
        
        public int Capacity { get; private set; }
        
        public ICollection<LectureScheduleDataModel> LectureSchedules { get; set; }
    }
}