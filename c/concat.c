char* concat(const char *firstString, const char *secondString)
{
    char *result = malloc(strlen(firstString) + strlen(secondString) + 1);
    strcpy(result, firstString);
    strcat(result, secondString);
    return result;
}
