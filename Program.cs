var builder = WebApplication.CreateBuilder(args); // ���������� �������� � ���������

builder.Services.AddControllers(); // Swagger ��� ������������ API

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

var app = builder.Build(); // ��������� Swagger � ������ ����������

if (app.Environment.IsDevelopment())

{
    app.UseSwagger();

    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();