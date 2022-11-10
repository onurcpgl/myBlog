<script setup>
import { onMounted,ref } from "vue";
import { getArticle } from "../../service/Article/article";
const data = ref();

onMounted(async() => {
    const result = await getArticle();
    const yenidizi = result.map(x => x.contents);
    console.log("yeni",yenidizi);
    data.value = result;
    console.log(data);
})
</script>

<template>
   
<div class="flex flex-row mt-5 m-8 ">
    <div class="basis-1/4  ">    
        <div class="overflow-x-auto relative shadow-md sm:rounded-lg mr-5">
        <table class="w-full text-sm text-left text-gray-500 dark:text-gray-400">
            <thead class="text-xs text-gray-700 uppercase dark:text-gray-400" >
                <tr>
                    <th scope="col" class="py-3 px-6 bg-gray-50 dark:bg-gray-800">
                        Kategoriler
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr >
                    <th scope="row" class="py-4 px-6 font-medium text-gray-900 whitespace-nowrap bg-gray-50 dark:text-white dark:bg-gray-800">
                        .NET
                    </th>
                </tr>
            </tbody>
        </table>
        </div>
    </div>
    <div class="basis-1/2  ">
        <a href="#" class="flex flex-col items-center bg-white rounded-lg border shadow-md md:flex-row md:max-w-full hover:bg-gray-100 dark:border-gray-700 dark:bg-gray-800 dark:hover:bg-gray-700"
            v-for="article in data"
        >
            <!-- <img class="object-cover w-full h-96 rounded-t-lg md:h-auto md:w-48 md:rounded-none md:rounded-l-lg"  alt=""> -->
            <div class="flex flex-col justify-conter p-4 leading-normal ">
                <h5 class="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">{{article.title.slice(0,25)}}</h5>
                <p class="mb-3 font-normal text-gray-700 dark:text-gray-400 max-w-ful ">{{article.contents.slice(0,125)}}</p>
            </div>
        </a> 
    </div>
    <div class="basis-1/4">
        <div class="overflow-x-auto relative shadow-md sm:rounded-lg ml-5">
        <table class="w-full text-sm text-left text-gray-500 dark:text-gray-400">
            <thead class="text-xs text-gray-700 uppercase dark:text-gray-400">
                <tr>
                    <th scope="col" class="py-3 px-6 bg-gray-50 dark:bg-gray-800">
                        En son eklenen makaleler
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr >
                    <th scope="row" class="py-4 px-6 font-medium text-gray-900 whitespace-nowrap bg-gray-50 dark:text-white dark:bg-gray-800">
                        Google Pixel Phone
                    </th>
                </tr>
            </tbody>
        </table>
        </div>
    </div>
</div>



</template>

<style scoped>
</style>
