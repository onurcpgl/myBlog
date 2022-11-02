//Kategorileri getiren fonksiyon.
export async function getCategory(){
    const response = await fetch("https://localhost:7229/categories")
        .then(person => person.json())
            .then(data => data)
    return response;
}