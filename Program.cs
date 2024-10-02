//*****************************************************************************
//** 1331. Rank Transform of an Array   leetcode                             **
//*****************************************************************************


/**
 * Note: The returned array must be malloced, assume caller calls free().
 */
int cmp(const void* a, const void* b) {
    return (*(int*)a - *(int*)b);
}

int* unique(int* arr, int* size) {
    int* temp = (int*)malloc(*size * sizeof(int));
    int j = 0;
    
    for (int i = 0; i < *size; i++) {
        if (i == 0 || arr[i] != arr[i - 1]) {
            temp[j++] = arr[i];
        }
    }
    *size = j;
    return temp;
}

int* arrayRankTransform(int* arr, int arrSize, int* returnSize) {
    int* t = (int*)malloc(arrSize * sizeof(int));
    for (int i = 0; i < arrSize; i++) {
        t[i] = arr[i];
    }

    // Sort the copied array
    qsort(t, arrSize, sizeof(int), cmp);

    // Remove duplicates
    int uniqueSize = arrSize;
    t = unique(t, &uniqueSize);

    int* ans = (int*)malloc(arrSize * sizeof(int));
    for (int i = 0; i < arrSize; i++) {
        int* pos = (int*)bsearch(&arr[i], t, uniqueSize, sizeof(int), cmp);
        ans[i] = (pos - t) + 1;
    }

    *returnSize = arrSize;
    free(t);  // Freeing the temporary sorted array
    return ans;
}