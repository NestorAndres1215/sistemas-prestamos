
using Application.DTOs.Auth;

namespace Application.Validators;

public static class UsuarioValidators
{
    public static List<string> ValidateRegister(RegisterUsuarioRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Username))
        {
            errors.Add("El nombre de usuario es obligatorio.");
        }
        else if (request.Username.Trim().Length < 3 ||
                 request.Username.Trim().Length > 50)
        {
            errors.Add("El nombre de usuario debe tener entre 3 y 50 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            errors.Add("El correo electrónico es obligatorio.");
        }
        else if (!System.Net.Mail.MailAddress.TryCreate(
                     request.Email.Trim(), out var address) ||
                 address.Address != request.Email.Trim())
        {
            errors.Add("El correo electrónico no tiene un formato válido.");
        }
        else if (request.Email.Trim().Length > 150)
        {
            errors.Add("El correo electrónico no puede superar los 150 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            errors.Add("La contraseña es obligatoria.");
        }
        else if (request.Password.Length < 8)
        {
            errors.Add("La contraseña debe tener al menos 8 caracteres.");
        }
        else if (request.Password.Length > 128)
        {
            errors.Add("La contraseña no puede superar los 128 caracteres.");
        }

        return errors;
    }
}
