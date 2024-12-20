import "./frameworks/vue.js"

var app = new Vue({
    el: '#app',
    data: {
        email: '',
        password: ''
    },
    methods: {
        login: async function () {
            try {
                const response = await fetch("./api/User/login", {
                    method: "POST",
                    headers: { "Content-Type": "application/json; charset=utf-8" },
                    body: JSON.stringify({ email: this.email, password: this.password }),
                });

                // Проверка на успешный ответ
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }

                // Преобразуем ответ в JSON
                const data = await response.json();

                // Извлекаем токен из ответа
                const token = data.token;
                if (!token) {
                    throw new Error('Token is missing in the response');
                }

                // Сохраняем токен в localStorage
                localStorage.setItem('jwtToken', token);
                window.location.href = "./main"
                
            } catch (error) {
                console.error('Login failed:', error);
            }
        }
    }
})