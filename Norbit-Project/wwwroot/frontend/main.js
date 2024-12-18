import "./frameworks/vue.js"

var app = new Vue({
    el: '#app',
    data: {
        token: localStorage.getItem('jwtToken')
    },
    methods: {
    }
})