using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ASC.Tests.TestUtilities
{
    public class FakeSession : ISession
    {
        public bool IsAvailable => true; // Giả lập session luôn khả dụng
        public string Id => Guid.NewGuid().ToString(); // Sinh ID ngẫu nhiên cho session
        public IEnumerable<string> Keys => sessionFactory.Keys; // Lấy danh sách khóa trong session

        private Dictionary<string, byte[]> sessionFactory = new Dictionary<string, byte[]>();

        public void Clear()
        {
            sessionFactory.Clear(); // Xóa tất cả dữ liệu trong session
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask; // Giả lập commit session mà không thực hiện gì
        }

        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask; // Giả lập load session mà không thực hiện gì
        }

        public void Set(string key, byte[] value)
        {
            sessionFactory[key] = value; // Lưu dữ liệu vào session
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            return sessionFactory.TryGetValue(key, out value); // Kiểm tra key có tồn tại không
        }

        public void Remove(string key) // <== Thêm phương thức này để sửa lỗi CS0535
        {
            sessionFactory.Remove(key); // Xóa một mục khỏi session
        }
    }
}
