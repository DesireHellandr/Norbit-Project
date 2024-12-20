import "./frameworks/vue.js"

const token = localStorage.getItem('jwtToken');


import {
    addBody, addComponent, addPlace, addUser, addCategory, addRole, updBody, updCategory, updComponent, updPlace, updRole, getAllBodies, getAllCategories, getAllComponents, getAllImages, getAllPlaces
} from "./requests/api.requests.js";

var categoriesList = Vue.component(
    "categories-list", {
    props: ["categories", "updateсomponents"],
    template: `
        <div>
        <label class="category-checkbox" v-for="category in categories" :key="category.id">
                            <input :value="category.id" type="checkbox"   :checked="selectedCategoryId === category.id"
        :disabled="isCheckboxDisabled(category.id)"
        @change="toggleCheckbox(category.id)">{{category.name}}
        </label>
        <button v-on:click="applyFilters" class="primary-button">Применить фильтр</button>
        </div>
        `,
   data() {
       return {
           selectedCategoryId: null,
       };
   },
        methods: {
            toggleCheckbox(categoryId) {

                if (this.selectedCategoryId === categoryId) {
                    this.selectedCategoryId = null;
                } else {

                    this.selectedCategoryId = categoryId;
                }
            },
            isCheckboxDisabled(categoryId) {

                return this.selectedCategoryId !== null && this.selectedCategoryId !== categoryId;
            },
        async applyFilters() {

            
            try {
                const response = await fetch('./api/Component/getByCategoryId/' + this.selectedCategoryId, {
                    method: 'GET',
                    headers: {
                        "Authorization": `Bearer ${token}`
                    }
                });

                if (!response.ok) throw new Error(`Ошибка: ${response.status}`);
                const data = await response.json();
                this.updateсomponents(data);
            } catch (error) {
                console.error('Ошибка при применении фильтров:', error);
            }
        },
    }
}
)

var componentsList = Vue.component("components-list", {
    props: ["components", "bodies", "places", "categories", "images"],
    template: `
    <div>
    <div>
      <table>
        <thead>
          <tr>
            <th>Название</th>
            <th>Дополнительно</th>
            <th>Цена</th>
            <th>Дата ревизии</th>
            <th>Находится</th>
            <th>Категория</th>
            <th>Корпус</th>
            <th>Действие</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="component in components" :key="component.id">
            <td>{{ component.name }}</td>
            <td>{{ component.note }}</td>
            <td>{{ component.price }}</td>
            <td>{{ component.dateAudit }}</td>
            <td>{{ getPlaceName(component.placeId) }}</td>
            <td>{{ getCategoryName(component.categoryId) }}</td>
            <td>{{ getBodyName(component.bodyId) }}</td>
            <td>
              <button class="primary-button" @click="openEditModal(component)">Редактировать</button>
              <button class="primary-button" @click="openDetailsModal(component)">Подробнее</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>

    <!-- Модальное окно -->
    <div v-if="isModalOpen" class="modal">
      <div class="modal-content">
        <span @click="closeModal" class="close">&times;</span>
        <h2>Редактировать компонент</h2>
        <label for="name">Название:</label>
        <input type="text" v-model="selectedComponent.name" />

        <label for="note">Дополнительно:</label>
        <input type="text" v-model="selectedComponent.note" />

        <label for="price">Цена:</label>
        <input type="number" v-model="selectedComponent.price" />

        <label for="dateAudit">Дата проверки:</label>
        <input type="text" v-model="selectedComponent.dateAudit" />

        <label for="bodyId">Выберите тело:</label>
        <select v-model="selectedComponent.bodyId">
          <option v-for="body in bodies" :key="body.id" :value="body.id">
            {{ body.name }}
          </option>
        </select>

        <!-- Выпадающий список для categoryId -->
        <label for="categoryId">Выберите категорию:</label>
        <select v-model="selectedComponent.categoryId">
          <option v-for="category in categories" :key="category.id" :value="category.id">
            {{ category.name }}
          </option>
        </select>

        <!-- Выпадающий список для placeId -->
        <label for="placeId">Выберите место:</label>
        <select v-model="selectedComponent.placeId">
          <option v-for="place in places" :key="place.id" :value="place.id">
            {{ place.name }}
          </option>
        </select>

        <!-- Выпадающий список для img -->
      <label for="img">Выберите изображение:</label>
      <select v-model="selectedComponent.img">
        <option v-for="image in images" :key="image" :value="image">
          {{ image }}
        </option>
      </select>

      <!-- Выпадающий список для pinoutImg -->
      <label for="pinoutImg">Выберите изображение для распиновки:</label>
      <select v-model="selectedComponent.pinoutImg">
        <option v-for="image in images" :key="image" :value="image">
          {{ image }}
        </option>
      </select>

        <button class="primary-button" @click="updateComponent">Сохранить</button>
        <button class="primary-button" @click="closeModal">Отмена</button>
      </div>
    </div>
    <div v-if="isDetailsModalOpen" class="modal">
      <div class="modal-content">
        <span @click="closeDetailsModal" class="close">&times;</span>
        <h2>Информация о компоненте</h2>

        <label>Название</label>
        <p>{{ selectedComponent.name }}</p>

        <label>Примечание</label>
        <p>{{ selectedComponent.note }}</p>

        <label>Категория:</label>
        <p>{{ getCategoryName(selectedComponent.categoryId) }}</p>

        <label>Корпус:</label>
        <p>{{ getBodyName(selectedComponent.categoryId) }}</p>

        <label>Место хранения:</label>
        <p>{{ getPlaceName(selectedComponent.placeId) }}</p>

        <label>Изображение:</label>
        <img :src="getImageSrc(selectedComponent.img)" width="128px" height="128px" alt="Изображение" />

        <label>Изображение для распиновки:</label>
        <img :src="getImageSrc(selectedComponent.pinoutImg)" width="128px" height="128px" alt="Изображение для распиновки" />

        <button class="primary-button" @click="closeDetailsModal">Отмена</button>
      </div>
    </div>
  </div>
    `,
    data() {
        return {
            isDetailsModalOpen: false,
            isModalOpen: false,
            selectedComponent: {
                name: '',
                note: '',
                price: null,
                dateAudit: '',
                img: '',
                pinoutImg: '',
                categoryIds: null, 
                bodyIds: null,     
                placeIds: null     
            },
        };
    },
    methods: {
    getImageSrc(filename) {
      return `/FileUpload/image/${filename}`;
    },
    openDetailsModal(component) {
    this.selectedComponent = component; 
    this.isDetailsModalOpen = true;
    },
    closeDetailsModal() {
        this.isDetailsModalOpen = false;
     },
    getPlaceName(placeId) {
        const place = this.places.find(p => p.id === placeId);
            return place ? place.name : 'Unknown';
    },
    getCategoryName(categoryId) {
        const category = this.categories.find(c => c.id === categoryId);
        return category ? category.name : 'Unknown';
    },
    getBodyName(bodyId) {
        const body = this.bodies.find(b => b.id === bodyId);
        return body ? body.name : 'Unknown';
    },
    openEditModal(component) {
      this.selectedComponent = JSON.parse(JSON.stringify(component));
      this.isModalOpen = true;
    },
    closeModal() {
      this.isModalOpen = false;
      this.selectedComponent = {};
    },
    async updateComponent() {
        try {
            const { id, name, note, price, dateAudit, img, pinoutImg, placeId, categoryId, bodyId } = this.selectedComponent;
            const result = await updComponent(id, name, note, price, dateAudit, img, pinoutImg, placeId, categoryId, bodyId);
            
            const index = this.components.findIndex(comp => comp.id === id);
            if (index !== -1) {
                this.$set(this.components, index, { ...this.selectedComponent });
            }
            this.closeModal();
        } catch (error) {
            console.error("Ошибка при обновлении компонента:", error);
        }
    },
}
});

var app = new Vue({
    el: '#app',
    data: {
        token: token,
        components: [],
        bodies: [],
        places: [],
        categories: [],
        images: [],
        isAddModalOpen: false,
        currentType: null,
        modalTitle: '',
        place: { id: null, name: '', location: '' },
        component: { id: null, name: '', note: '', price: null, dateAudit: '', img: '', pinoutImg: '', placeId: null, bodyId: null, categoryId: null },
        body: { id: null, name: '', description: '', img: '', schematicImg: '' },
        category: { id: null, name: '', description: '', parentCategoryId: null },
        role: { id: null, name: '', permission: '' },
        user: { id: null, name: '', email: '', password: '', roleId: null }
    },
    async created() {
        this.components = await getAllComponents(token);
        this.bodies = await getAllBodies(token);
        this.places = await getAllPlaces(token);
        this.categories = await getAllCategories(token);
        this.images = await getAllImages(token);
    },
    methods: {
        updateсomponents(components) {
            this.components = components;
        },
        openAddModal(type) {
            this.currentType = type; // Установка текущего типа
            this.modalTitle = `Добавление из списка`; // Заголовок
            this.isAddModalOpen = true; // Открытие модального окна
            // Сброс значений полей ввода (если необходимо)
            this.resetFields();
        },
        closeAddModal() {
            this.isAddModalOpen = false;
        },
        resetFields() {
            this.place = { id: null, name: '', location: '' };
            this.component = { id: null, name: '', note: '', price: null, dateAudit: '', img: '', pinoutImg: '', placeId: null, bodyId: null, categoryId: null };
            this.body = { id: null, name: '', description: '', img: '', schematicImg: '' };
            this.category = { id: null, name: '', description: '', parentCategoryId: null };
            this.role = { id: null, name: '', permission: '' };
            this.user = { id: null, name: '', email: '', password: '', roleId: null };
        },
        toLogin() {
            window.location.href = "./";
        },
        async addData() {
            try {
                switch (this.currentType) {
                    case 'place':
                        await addPlace(this.place.name, this.place.location, token);
                        break;
                    case 'component':
                        console.log(this.component.placeId, this.component.bodyId, this.component.categoryId);
                        await addComponent(
                            this.component.name,
                            this.component.note,
                            this.component.price,
                            this.component.dateAudit,
                            this.component.img,
                            this.component.pinoutImg,
                            this.component.placeId,
                            this.component.bodyId,
                            this.component.categoryId,
                            token
                        );
                        location.reload();
                        break;
                    case 'body':
                        await addBody(this.body.name, this.body.description, this.body.img, this.body.schematicImg, token);
                        location.reload();
                        break;
                    case 'category':
                        await addCategory(this.category.name, this.category.description, this.category.parentCategoryId, token);
                        location.reload();
                        break;
                    case 'role':
                        await addRole(this.role.name, this.role.permission, token);
                        location.reload();
                        break;
                    case 'user':
                        await addUser(this.user.name, this.user.email, this.user.password, this.user.roleId, token);
                        location.reload();
                        break;
                    default:
                        break;
                }
                this.closeAddModal();
            } catch (error) {
                console.error("Ошибка при добавлении данных:", error);
            }
        }
    },
    components: {
        'categories-list': categoriesList
    }
})