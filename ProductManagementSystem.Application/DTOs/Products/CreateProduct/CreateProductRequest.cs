namespace ProductManagementSystem.Application.DTOs.Products.CreateProduct;

public record CreateProductRequest
{
    /// <summary>
    /// <para>اسم: نام محصول</para>
    /// <para>تعداد کاراکتر مجاز: 100</para>
    /// <para>اجباری</para>
    /// </summary>
    /// <example>محصول شماره 1</example>
    public string? Name { get; set; }

    /// <summary>
    /// <para>اسم: ایمل تولید</para>
    /// <para>اجباری</para>
    /// </summary>
    /// <example>example1@gmail.com</example>
    public string? ManufactureEmail { get; set; }

    /// <summary>
    /// <para>اسم: تاریخ تولید</para>
    /// <para>اجباری</para>
    /// </summary>
    public DateTime ProduceDate { get; set; }

    /// <summary>
    /// <para>اسم: شماره تلفن تولید</para>
    /// <para>تعداد کاراکتر مجاز: 11</para>
    /// <para>اجباری</para>
    /// </summary>
    /// <example>09015556644</example>
    public string? ManufacturePhone { get; set; }

    /// <summary>
    /// <para>اسم: موجود است؟</para>
    /// <para>اجباری</para>
    /// </summary>
    public bool IsAvailable { get; set; }
}

// because of limitation of 'example' tag on 'positional records', for a sample of documentation, make this request
//public record CreateProductRequest(
//    string? Name,
//    string? ManufactureEmail,
//    DateTime ProduceDate,
//    string? ManufacturePhone,
//    bool IsAvailable);
