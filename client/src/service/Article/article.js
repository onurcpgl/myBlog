//Makalelerin hepsini getiren fonksiyon
export async function getArticle(){
    const response = await fetch("https://localhost:7229/article")
        .then(person => person.json())
            .then(data => data)
    return response;
}

//Makale ekleme fonksiyonu
export async function postArticle(value){
    console.log();
    const response = await fetch("https://localhost:7229/article",{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body : JSON.stringify(value._rawValue),
    });
    
    return response;
}
