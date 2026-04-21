using System;
using System.Collections.Generic;
using System.Text;

using System.Net.Http.Json;
using GameTracker.Models; // ดึงแม่พิมพ์ Game ของเรามาใช้งาน

namespace GameTracker.Services
{
    public class RawgApiService
    {
        private readonly HttpClient _httpClient;

        // ⚠️ สำคัญ: เอา API Key ที่คุณได้จากเว็บ RAWG มาใส่ตรงนี้
        private const string ApiKey = "c36c04a598ad4131a503367c9fb5ae7b";
        private const string BaseUrl = "https://api.rawg.io/api/";

        public RawgApiService()
        {
            _httpClient = new HttpClient();
        }

        // ฟังก์ชันสำหรับค้นหาเกมตามชื่อ (จะเอาไปใช้ในหน้า Search)
        public async Task<List<Game>> SearchGamesAsync(string query)
        {
            // ถ้าไม่ได้พิมพ์อะไรมาเลย ให้ส่งรายการว่างๆ กลับไป
            if (string.IsNullOrWhiteSpace(query))
                return new List<Game>();

            try
            {
                // สร้าง URL ตัวเต็ม
                var url = $"{BaseUrl}games?key={ApiKey}&search={query}";

                // ยิงคำขอไปที่ API และแปลง JSON กลับมาเป็นคลาส GameResponse ของเรา
                var response = await _httpClient.GetFromJsonAsync<GameResponse>(url);

                // ถ้ามีข้อมูล (Results) ให้ส่งกลับไป ถ้าไม่มีให้ส่ง List ว่างๆ
                return response?.Results ?? new List<Game>();
            }
            catch (Exception ex)
            {
                // เผื่อกรณีเน็ตหลุด หรือ API มีปัญหา
                Console.WriteLine($"เกิดข้อผิดพลาดในการดึงข้อมูล: {ex.Message}");
                return new List<Game>();
            }
        }
    }
}