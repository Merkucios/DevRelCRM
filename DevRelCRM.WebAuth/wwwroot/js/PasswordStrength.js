// Ожидаем, пока DOM полностью загрузится
$(document).ready(function () {
    // Привязываем обработчик события ввода текста к полю с паролем
    $('#password').on('input', function () {
        // Вызываем функцию для проверки силы пароля при каждом вводе
        validatePasswordStrength($(this).val());
    });

    function validatePasswordStrength(password) {
        // Регулярные выражения для проверки условий
        var uppercaseRegex = /[A-Z]/;
        var digitRegex = /\d/;
        var specialCharRegex = /[!@#$%^&*(),.?":{}|<>]/;

        // Переменная для отслеживания выполненных условий
        var strength = 0;

        if (password.length >= 8) {
            strength++;
        }

        if (uppercaseRegex.test(password)) {
            strength++;
        }

        if (digitRegex.test(password)) {
            strength++;
        }

        if (specialCharRegex.test(password)) {
            strength++;
        }

        
        var messages = [
            "Пароль должен содержать цифру",
            "Пароль должен содержать заглавную букву",
            "Пароль должен содержать специальный символ",
            "Пароль должен содержать минимум 8 символов"
        ];

        var icons = [
            "bi-check2",
            "bi-x-lg"       
        ];

        // Список сообщений
        var message = "<ul class='list-unstyled'>";

        for (var i = 0; i < messages.length; i++)
        {
            
            var conditionMet = false;

            switch (i) {
                case 0:
                    conditionMet = digitRegex.test(password);
                    break;
                case 1:
                    conditionMet = uppercaseRegex.test(password);
                    break;
                case 2:
                    conditionMet = specialCharRegex.test(password);
                    break;
                case 3:
                    conditionMet = password.length >= 8;
                    break;
                default:
                    break;
            }

            var iconClass = conditionMet ? "text-success" : "text-danger";
            var icon = (i < strength) ? icons[0] : icons[1];

            message += "<li class='" + iconClass + "'><i class='bi " + icon + "'></i> " + messages[i] + "</li>";
        }
        message += "</ul>";

        // Выводим сформированное сообщение о силе пароля в элемент с id #password-strength-info
        $('#password-strength-info').html(message);
    }
});