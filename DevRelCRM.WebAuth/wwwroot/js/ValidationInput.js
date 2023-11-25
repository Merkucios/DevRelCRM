$(document).ready(function () {

    // Добавляем метод валидации "NoNumbers" для проверки, что значение не содержит цифры
    $.validator.addMethod("NoNumbers", function (value, element) {
        return this.optional(element) || /^[^0-9]+$/.test(value);
    }, "Не должно содержать цифры");

    // Добавляем метод валидации "OnlyASCII" для проверки, что значение содержит только ASCII символы
    $.validator.addMethod("OnlyASCII", function (value, element) {
        return this.optional(element) || /^[\x00-\x7F]+$/.test(value);
    }, "Должно содержать только ASCII символы");

    // Включаем валидацию формы с использованием jQuery Validate
    document.getElementById('success-message').style.display = 'none';

    $('form').validate({
        submitHandler: function (form) {
            // Предотвращаем стандартное поведение отправки формы
            event.preventDefault();

            // Если форма валидна, скрываем форму и отображаем сообщение об успехе
            document.getElementById('main').style.display = 'none';
            document.getElementById('success-message').style.display = 'block';

            // Ждем 3 секунды перед перенаправлением
            setTimeout(function () {}, 3000);
        }
    });

    // Добавляем правила валидации для каждого поля
    $('#Input_Surname').rules('add', {
        required: true,
        NoNumbers: true,
        messages: {
            required: 'Введите фамилию',
            NoNumbers: 'Фамилия не должна содержать цифры'
        }
    });

    $('#Input_Name').rules('add', {
        required: true,
        NoNumbers: true,
        messages: {
            required: 'Введите имя',
            NoNumbers: 'Имя не должно содержать цифры'
        }
    });

    $('#Input_Patronym').rules('add', {
        NoNumbers: true,
        messages: {
            NoNumbers: 'Отчество не должно содержать цифры'
        }
    });


    $('#Input_NickName').rules('add', {
        required: true,
        OnlyASCII: true,
        messages: {
            required: 'Введите никнейм',
            OnlyASCII: 'Никнейм состоит из латинских символов',
        }
    });

    $('#Input_Email').rules('add', {
        required: true,
        email: true,
        messages: {
            required: 'Введите email',
            email: 'Введите корректный email : example@example.com'
        }
    });

    $('#password').rules('add', {
        required: true,
        messages: {
            required: 'Введите пароль'
        }
    });

    $('#Input_ConfirmPassword').rules('add', {
        required: true,
        equalTo: '#password', 
        messages: {
            required: 'Подтвердите пароль',
            equalTo: 'Пароли не совпадают'
        }
    });
});

(() => {
    'use strict';

    // Получаем форму, требующую валидацию

    const formsWithValidation = document.querySelectorAll('.needs-validation');

    // Итерируем по всем формам с классом 'needs-validation'
    Array.from(formsWithValidation).forEach(form => {

        // Добавляем слушатель события отправки формы
        form.addEventListener('submit', event => {

            // Проверяем валидность формы
            if (!form.checkValidity()) {
                document.getElementById('success-message').style.display = 'none';
                event.preventDefault();
                event.stopPropagation();
            }
            else {
                document.getElementById('main').style.display = 'none';
                document.getElementById('login').style.display = 'none';
                document.getElementById('success-message').style.display = 'block';
            }
            // Добавляем класс 'was-validated' к форме для стилизации валидированных полей
            form.classList.add('was-validated');
        }, false);
    });
})();

