function displayPreperties() {
    var properties = [];

    for (var property in document) {
        properties.push(property);
    }

    properties.sort;

    for (var property in properties) {
        console.log(properties[property]);
    }
}

displayPreperties();