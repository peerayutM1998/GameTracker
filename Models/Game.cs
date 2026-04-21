using System;
using System.Collections.Generic;
using System.Text;

using System.Text.Json.Serialization;

namespace GameTracker.Models // เปลี่ยน GameTracker เป็นชื่อโปรเจกต์ของคุณ
{
    public class Game
    {
        // --- ข้อมูลที่ได้มาจาก RAWG API ---
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("background_image")]
        public string BackgroundImage { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        // --- ข้อมูลสำหรับบันทึกในแอปของเราเอง (Local Data) ---

        // แพลตฟอร์มที่เล่น (เช่น Nintendo Switch)
        public string Platform { get; set; }

        // ความคืบหน้า (0 - 100%)
        public int Progress { get; set; }

        // สถานะการเล่น (เช่น "Playing", "Completed", "Plan to Play")
        public string PlayStatus { get; set; }

        // กดเป็นเกมโปรดหรือไม่
        public bool IsFavorite { get; set; }
    }

    // คลาสนี้ใช้สำหรับรับก้อนข้อมูล JSON จาก API ที่ส่งมาเป็น Array ชื่อ results
    public class GameResponse
    {
        [JsonPropertyName("results")]
        public List<Game> Results { get; set; }
    }
}