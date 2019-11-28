using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Course.WebApi.Models
{
    [Table("WeatherForecast")] //自訂db table name 
    public class WeatherForecast
    {
        [Key]//主键
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//透過db自動產出的唯一識別值
        [Column("id")] //自訂db table 欄位名稱 
        public int Id { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("temperature_c")]
        public int TemperatureC { get; set; }

        [Column("temperature_f")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        [Column("summary")]
        public string Summary { get; set; }
    }
}