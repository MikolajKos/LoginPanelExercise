using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanelLesson.MVVM.Models.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; init; }
        [MaxLength(50)]
        public string UserLogin { get; init; }
        [MaxLength(50)]
        public string UserPassword { get; init; }
    }
}
