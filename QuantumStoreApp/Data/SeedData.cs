namespace QuantumStore.Data
{
    using Microsoft.EntityFrameworkCore;

    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            // إضافة الفئات
            context.ProductCategories.AddRange(
                new ProductCategory { Name = "Electronics" },
                new ProductCategory { Name = "Books" },
                new ProductCategory { Name = "Clothing" }
            );

            // إضافة المنتجات
            context.Products.AddRange(
                new Product
                {
                    Name = "Laptop",
                    Price = 1200.99m,
                    ExpirationDate = new DateTime(2027, 4, 25, 0, 0, 0),
                    ProductCategoryId = 1 // مرتبط بـ Electronics
                },
                new Product
                {
                    Name = "Novel: The Great Gatsby",
                    Price = 15.99m,
                    ExpirationDate = new DateTime(2027, 4, 25, 0, 0, 0),
                    ProductCategoryId = 2 // مرتبط بـ Books
                },
                new Product
                {
                    Name = "T-Shirt",
                    Price = 9.99m,
                    ExpirationDate = new DateTime(2027, 4, 25, 0, 0, 0),
                    ProductCategoryId = 3 // مرتبط بـ Clothing
                }
            );

            // إضافة العملاء
            context.Customers.AddRange(
                new Customer
                {
                    Name = "Alice Johnson",
                    Email = "alice@example.com",
                    PhoneNumber = "1234567890"
                },
                new Customer
                {
                    Name = "Bob Smith",
                    Email = "bob@example.com",
                    PhoneNumber = "0987654321"
                },
                new Customer
                {
                    Name = "Charlie Brown",
                    Email = "charlie@example.com",
                    PhoneNumber = "5555555555"
                }
            );
            context.SaveChanges();
            // إضافة المراجعات المرتبطة بالعملاء والمنتجات
            context.ProductReviews.AddRange(
                new ProductReview
                {
                    ReviewText = "Excellent quality product.",
                    Rating = 5,
                    ReviewDate = new DateTime(2027, 4, 25, 0, 0, 0),
                    ProductId = 1, // مرتبط بـ Laptop
                    CustomerId = 1 // مرتبط بـ Alice
                },
                new ProductReview
                {
                    ReviewText = "Very useful book.",
                    Rating = 4,
                    ReviewDate = new DateTime(2027, 4, 25, 0, 0, 0),
                    ProductId = 2, // مرتبط بـ The Great Gatsby
                    CustomerId = 2 // مرتبط بـ Bob
                },
                new ProductReview
                {
                    ReviewText = "Comfortable and affordable.",
                    Rating = 4,
                    ReviewDate = new DateTime(2027, 4, 25, 0, 0, 0),
                    ProductId = 3, // مرتبط بـ T-Shirt
                    CustomerId = 3 // مرتبط بـ Charlie
                }
            );

            // حفظ البيانات في قاع دة البيانات
            context.SaveChanges();
        }
    }
}
