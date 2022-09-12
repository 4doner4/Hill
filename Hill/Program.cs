using System.Text;

StringBuilder sbWord = new StringBuilder();
StringBuilder sbKey = new StringBuilder();
int matrixSize;
int[,] matrix;
int[] arrKeys;
string str = "asdasd";
string key = "bas";

Console.WriteLine(Encrypt(str, key));

string Encrypt(string word, string key = "")
{
    sbWord.Append(word);
    sbKey.Append(key);

    matrixSize = (int)(Math.Ceiling(Math.Sqrt(sbWord.Length)));
    matrix = new int[matrixSize, matrixSize];
    arrKeys = new int[matrixSize];

    int k = 0;

    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            if (k >= sbWord.Length) matrix[i, j] = 25;
            else matrix[i, j] = sbWord[k] - ((int)'a');

            k++;

        }
    }

    int wallKey = 0;
    int[] arrTmp = new int[matrixSize];


    int[,] matrixOfNewEncryptedValues = new int[matrixSize, matrixSize];

    for (int i = 0; i < matrixSize; i++)
    {
        for (int ind = 0; ind < matrixSize; ind++) arrTmp[ind] = 0;

        for (int j = 0; j < matrixSize; j++)
        {
            if (wallKey >= sbKey.Length) arrKeys[j] = 25;
            else arrKeys[j] = sbKey[wallKey] - ((int)'a');
            wallKey++;
        }


        for (int j = 0; j < matrixSize; j++)
        {
            for (int ind = 0; ind < matrixSize; ind++)
            {
                arrTmp[j] += matrix[ind, j] * arrKeys[ind];
            }
        }

        for (int ind = 0; ind < matrixSize; ind++)
        {
            matrixOfNewEncryptedValues[i, ind] = arrTmp[ind] % 26;
        }
    }

    StringBuilder sbResult = new StringBuilder();

    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            sbResult.Append((char)(matrixOfNewEncryptedValues[i, j] + (int)'a'));
        }
    }
    return sbResult.ToString();
}