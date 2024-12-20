async function getAllComponents(token) {
    const response = await fetch("./api/Component/getAll", {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });
    const result = await response.json();
    return result;
}

async function getAllImages(token) {
    const response = await fetch("./FileUpload/images", {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });
    const result = await response.json();
    return result;
}

async function getAllCategories(token) {
    const response = await fetch("./api/Category/getAll", {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });
    const result = await response.json();
    return result;
}
async function getAllPlaces(token) {
    const response = await fetch("./api/Place/getAll", {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });
    const result = await response.json();
    return result;
}
async function getAllBodies(token) {
    const response = await fetch("./api/Body/getAll", {
        method: "GET",
        headers: {
            "Authorization": `Bearer ${token}`
        }
    });
    const result = await response.json();
    return result;
}

async function addPlace(name, location, token) {
    const response = await fetch("./api/Place", {
        method: "POST",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "name": name,
            "location": location
        })
    });
    return response.json();
}

async function updPlace(id, name, location, token) {
    const response = await fetch("./api/Place/" + id, {
        method: "PUT",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "id": id,
            "name": name,
            "location": location
        })
    });
    return response.json();
}

async function addComponent(name, note, price, dateAudit, img, pinoutImg, placeId, bodyId, categoryId, token) {
    console.log(placeId, categoryId, bodyId);
    const response = await fetch("./api/Component", {
        method: "POST",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "name": name,
            "note": note,
            "price": price,
            "dateAudit": dateAudit,
            "img": img,
            "pinoutImg": pinoutImg,
            "placeId": placeId,
            "categoryId": categoryId,
            "bodyId": bodyId
        })
    });
    return response.json();
}

async function updComponent(id, name, note, price, dateAudit, img, pinoutImg, placeId, categoryId, bodyId, token) {
    const response = await fetch("./api/Component/" + id, {
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
            "dateAudit": dateAudit,
            "img": img,
            "pinoutImg": pinoutImg,
            "placeId": placeId,
            "categoryId": categoryId,
            "bodyId": bodyId
        })
    });
    return response.json();
}

async function addBody(name, description, img, schematicImg, token) {
    const response = await fetch("./api/Body", {
        method: "POST",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "name": name,
            "description": description,
            "img": img,
            "schematicImg": schematicImg
        })
    });
    return response.json();
}

async function updBody(id, name, description, img, schematicImg, token) {
    const response = await fetch("./api/Body/" + id, {
        method: "PUT",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "id": id,
            "name": name,
            "description": description,
            "img": img,
            "schematicImg": schematicImg
        })
    });
    return response.json();
}

async function addCategory(name, description, parentCategoryId, token) {
    const response = await fetch("./api/Category", {
        method: "POST",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "name": name,
            "description": description,
            "parentCategoryId": parentCategoryId
        })
    });
    return response.json();
}

async function updCategory(id, name, description, parentCategoryId, token) {
    const response = await fetch("./api/Category/" + id, {
        method: "PUT",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "id": id,
            "name": name,
            "description": description,
            "parentCategoryId": parentCategoryId
        })
    });
    return response.json();
}

async function addRole(name, permission, token) {
    const response = await fetch("./api/Role", {
        method: "POST",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "name": name,
            "permission": permission
        })
    });
    return response.json();
}

async function updRole(id, name, permission, token) {
    const response = await fetch("./api/Role/" + id, {
        method: "PUT",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "id": id,
            "name": name,
            "permission": permission
        })
    });
    return response.json();
}

async function addUser(name, email, password, roleId, token) {
    const response = await fetch("./api/User/register", {
        method: "POST",
        headers: {
            "Authorization": `Bearer ${token}`,
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            "name": name,
            "email": email,
            "password": password,
            "roleId": roleId
        })
    });
    return response.json();
}


export { addBody, addComponent, addPlace, addUser, addCategory, addRole, updBody, updCategory, updComponent, updPlace, updRole, getAllBodies, getAllCategories, getAllComponents, getAllImages, getAllPlaces };