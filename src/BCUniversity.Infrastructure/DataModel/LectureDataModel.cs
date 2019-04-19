using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using BCUniversity.Infrastructure.DataModel.Common;

namespace BCUniversity.Infrastructure.DataModel
{
    [Table("lecture")]
    public class LectureDataModel: EntityDataModelBase
    {
        public string Name { get; set; }
        
        public ICollection<LectureScheduleDataModel> LectureSchedules { get; set; }
    }
}