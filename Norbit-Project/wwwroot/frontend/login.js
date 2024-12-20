import "./frameworks/vue.js"
import "https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js";

var app = new Vue({
    el: '#app',
    data: {
        email: '',
        password: ''
    },
    methods: {
        login: async function () {
            try {
                const response = await axios.post("./api/User/login", {
                    email: this.email,
                    password: this.password
                }, {
                    headers: { "Content-Type": "application/json; charset=utf-8" }
                });

                if (response.status !== 200) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }

                const token = response.data.token;
                if (!token) {
                    throw new Error('Token is missing in the response');
                }

                localStorage.setItem('jwtToken', token);

                window.location.href = "/main"

            } catch (error) {
                console.error('Login failed:', error);
            }
        }
    }
});