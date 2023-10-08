using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class ApiEscuelaContextSeed
{
    public static async Task SeedAsync(ApiEscuelaContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.Roles.Any())
            {
                using (var readerRole = new StreamReader(ruta + @"persistence/Data/Csv/Role.csv"))
                {
                    using (var csv = new CsvReader(readerRole, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Role>();
                        context.Roles.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Classes.Any())
            {
                using (var readerClass = new StreamReader(ruta + @"/Data/Csv/Class.csv"))
                {
                    using (var csv = new CsvReader(readerClass, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Class>();
                        context.Classes.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Users.Any())
            {
                using (var readerUser = new StreamReader(ruta + @"/Data/Csv/User.csv"))
                {
                    using (var csv = new CsvReader(readerUser, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<User>();
                        context.Users.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Teachers.Any())
            {
                using (var readerTeacher = new StreamReader(ruta + @"/Data/Csv/Teacher.csv"))
                {
                    using (var csv = new CsvReader(readerTeacher, CultureInfo.InvariantCulture))
                    {
                        var list = csv.GetRecords<Teacher>();
                        context.Teachers.AddRange(list);
                        await context.SaveChangesAsync();
                    }
                }
            }
            if (!context.Students.Any())
            {
                using (var readerStudents = new StreamReader(ruta + @"\Data\Csv/Student.csv"))
                {
                    using (var csv = new CsvReader(readerStudents, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Student>();
                        List<Student> entidad = new List<Student>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Student
                            {
                                Id = item.Id,
                                Name = item.Name,
                                Lastname = item.Lastname,
                                ClassIdFk = item.ClassIdFk

                            });
                        }

                        context.Students.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }

                }
            }
            if (!context.Subjects.Any())
            {
                using (var readerSubject = new StreamReader(ruta + @"\Data\Csv/Subject.csv"))
                {
                    using (var csv = new CsvReader(readerSubject, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<Subject>();
                        List<Subject> entidad = new List<Subject>();
                        foreach (var item in list)
                        {
                            entidad.Add(new Subject
                            {
                                Id = item.Id,
                                Name = item.Name,
                                TeacherIdFk = item.TeacherIdFk,
                                StudentIdFk = item.StudentIdFk
                            });
                        }

                        context.Subjects.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }

                }
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiEscuelaContext>();
            logger.LogError(ex.Message);
        }
    }

    public static async Task SeedRolesAsync(ApiEscuelaContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>()
                        {
                            new Role{Id=1, Name="Student"},
                            new Role{Id=2, Name="Teacher"},

                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiEscuelaContext>();
            logger.LogError(ex.Message);
        }
    }
}