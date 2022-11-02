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
    <div class="flex flex-row justify-center gap-4 p-5 mt-5">
        <!--Son Eklenen makaleler-->
        <div class="">     
            <a href="#" class="block p-6 max-w-sm bg-white rounded-lg border border-gray-200 shadow-md hover:bg-gray-100 dark:bg-gray-800 dark:border-gray-700 dark:hover:bg-gray-700">      
                <h5 class="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">Son eklenen makaleler !</h5>
                <ul class="mb-8 space-y-4 text-left text-gray-500 dark:text-gray-400">
                    <li class="flex items-center space-x-3">
                        <!-- Icon -->
                        <svg class="flex-shrink-0 w-5 h-5 text-green-500 dark:text-green-400" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd"></path></svg>
                        <span>Individual configuration</span>
                    </li>
                </ul>
            </a>
        </div>
        <!-- Makalelerin olacağı alan -->
        <div class="grid grid-rows-3 grid-flow-col gap-4" >     
            <div class="p-6 max-w-sm bg-white rounded-lg border border-gray-200 shadow-md dark:bg-gray-800 dark:border-gray-700" v-for="article in data">
                <a href="#">
                    <h5 class="mb-2 text-2xl font-bold tracking-tight text-gray-900 dark:text-white">{{article.title.slice(0,40)}}...</h5>
                </a>
                <p class="mb-3 font-normal text-gray-700 dark:text-gray-400">{{article.contents.slice(0,150)}}...</p>
                <a href="#" class="inline-flex items-center py-2 px-3 text-sm font-medium text-center text-white bg-blue-700 rounded-lg hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">
                    Devamını oku
                    <svg aria-hidden="true" class="ml-2 -mr-1 w-4 h-4" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M10.293 3.293a1 1 0 011.414 0l6 6a1 1 0 010 1.414l-6 6a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-4.293-4.293a1 1 0 010-1.414z" clip-rule="evenodd"></path></svg>
                </a>
            </div>
        </div>
    </div>
</template>

<style scoped>
</style>
