import "./frameworks/vue.js"

const token = localStorage.getItem('jwtToken');

async function getAllComponents() {
    const response = await fetch("./api/Component/getAll", {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });
    const result = await response.json();
    return result;
}
async function updComponent(id, name, note, price, dateAudit, placeId, categoryId, bodyId) {
    console.log(bodyId);
    const response = await fetch("./api/Component/"+id, {
        method: "PUT",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "id": id,
            "name": name,
            "note": note,
            "price": price,
            "img": "string",
            "pinoutImg": "string",
            "dateAudit": dateAudit,
            "placeId": placeId,
            "categoryId": categoryId,
            "bodyId": bodyId
        })
    });
}

async function getAllCategories() {
    const response = await fetch("./api/Category/getAll", {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });
    const result = await response.json();
    return result;
}
async function getAllPlaces() {
    const response = await fetch("./api/Place/getAll", {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });
    const result = await response.json();
    return result;
}
async function getAllBodies() {
    const response = await fetch("./api/Body/getAll", {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });
    const result = await response.json();
    return result;
}

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
    props: ["components", "bodies", "places", "categories"],
    template: `
    <div>
    <div>
      <table>
        <thead>
          <tr>
            <th>Название</th>
            <th>Дополнительно</th>
            <th>Цена</th>
            <th>Год проверки</th>
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

        <label for="dateAudit">Год проверки:</label>
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

        <button class="primary-button" @click="updateComponent">Сохранить</button>
        <button class="primary-button" @click="closeModal">Отмена</button>
      </div>
    </div>
  </div>
    `,
    data() {
        return {
            isModalOpen: false,
            selectedComponent: {
                name: '',
                note: '',
                price: null,
                dateAudit: '',
                categoryIds: null, 
                bodyIds: null,     
                placeIds: null     
            },
        };
    },
    methods: {
        getPlaceName(placeId) {
        console.log(this.places)
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
            const { id, name, note, price, dateAudit, placeId, categoryId, bodyId } = this.selectedComponent;
            const result = await updComponent(id, name, note, price, dateAudit, placeId, categoryId, bodyId);
            
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
    },
    async created() {
        this.components = await getAllComponents();
        this.bodies = await getAllBodies();
        this.places = await getAllPlaces();
        this.categories = await getAllCategories();
    },
    methods: {
        updateсomponents(components) {
            this.components = components;
        }
    },
    components: {
        'categories-list': categoriesList
    }
})