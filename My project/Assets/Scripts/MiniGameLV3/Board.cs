using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Board : MonoBehaviour
{
    private static readonly KeyCode[] SUPPORTED_KEYS = new KeyCode[] {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, 
        KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, 
        KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, 
        KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, 
        KeyCode.Y, KeyCode.Z,
    };

    private Row[] rows;

    private string[] solutions;
    private string[] validWords;
    private string word;

    private int rowIndex;
    private int columnIndex;
    public int Win;
    
        
    [Header("States")]
    public Tile.State emptyState;
    public Tile.State occupiedState;
    public Tile.State correctState;
    public Tile.State wrongSpotState;
    public Tile.State incorrectState;

    [Header("UI")]
    public GameObject tryAgainButton;
    public GameObject newWordButton;
    public TextMeshProUGUI invalidWordText;
    [SerializeField] private GameObject exit;
    
    [Header("Hint")]
    //public Image hintImage;
    public TextMeshProUGUI hintText;

    private void Awake(){
        rows = GetComponentsInChildren<Row>();
    }

    private void Start()
    {
        exit.SetActive(false);
        Win = 0;
        LoadData();
        NewGame();
    }

    public void NewGame(){
        ClearBoard();
        SetRandomWord();
        SetRandomHint();
        enabled = true;
        newWordButton.SetActive(false);
    }
    
    public void TryAgain(){
        ClearBoard();
        enabled = true;
        tryAgainButton.SetActive(false);
    }

    public void Exit()
    {
        ExitGame();
        enabled = true;
    }

    private void LoadData(){
        TextAsset textFile = Resources.Load("official_wordle_all") as TextAsset;
        validWords = textFile.text.Split('\n');

        textFile = Resources.Load("official_wordle_common") as TextAsset;
        solutions = textFile.text.Split('\n');
    }

    private void SetRandomWord(){
        word = solutions[Random.Range(0,solutions.Length)];
        word = word.ToLower().Trim();
  
    }

    private void SetRandomHint()
    {
        switch (word.ToLower()){
            case "mixer":
                hintText.text = "Device used for mixing ingredients";
                hintText.gameObject.SetActive(true);
                break;
            case "apron":
                hintText.text = "Một chiếc áo bảo hộ để che phủ người khi nấu ăn";
                hintText.gameObject.SetActive(true);
                break;
            case "plate":
                hintText.text = "Một cái đĩa dùng để đựng thức ăn";
                hintText.gameObject.SetActive(true);
                break;
            case "knife":
                hintText.text = "Dụng cụ để cắt và chặt";
                hintText.gameObject.SetActive(true);
                break;
            case "spoon":
                hintText.text = "Vật dụng để múc và khuấy";
                hintText.gameObject.SetActive(true);
                break;
            case "stick":   
                hintText.text = "Cái que nhỏ để xiên";
                hintText.gameObject.SetActive(true);
                break;
            case "stove":
                hintText.text = "Bếp để nấu ăn, bếp lò";
                hintText.gameObject.SetActive(true);
                break;
            case "sugar":
                hintText.text = "Một thứ bột màu trắng rất ngọt";
                hintText.gameObject.SetActive(true);
                break;
            case "glass":
                hintText.text = "Cái cốc, cái ly";
                hintText.gameObject.SetActive(true);
                break;
            case "phone":
                hintText.text = "Thiết bị di động để liên lạc";
                hintText.gameObject.SetActive(true);
                break;
            case "games":
                hintText.text = "Trò chơi";
                hintText.gameObject.SetActive(true);
                break;
            case "hello":
                hintText.text = "Xin chào trong tiếng Anh là gì nhỉ?";
                hintText.gameObject.SetActive(true);
                break;            
            
        }
        
    }

    private void Update()
    {
        Row currentRow = rows[rowIndex];

        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            
            columnIndex = Mathf.Max(columnIndex -1, 0);
            currentRow.tiles[columnIndex].SetLetter('\0');
            currentRow.tiles[columnIndex].SetState(emptyState);
        }

        else if  (columnIndex >= rows[rowIndex].tiles.Length)
        {
                if(Input.GetKeyDown(KeyCode.Return)){
                    SubmitRow(currentRow);
                }
        }
        else
        {
            for (int i = 0; i < SUPPORTED_KEYS.Length; i++)
            {
                if (Input.GetKeyDown(SUPPORTED_KEYS[i]))
                {
                    currentRow.tiles[columnIndex].SetLetter((char)SUPPORTED_KEYS[i]);
                    currentRow.tiles[columnIndex].SetState(occupiedState);

                    columnIndex++;
                    break;
                }
            }
        }
        
        
    }

    private void SubmitRow(Row row)
    {
        string remaining = word;

        for(int i = 0; i < row.tiles.Length; i++){
            Tile tile = row.tiles[i];
            if (tile.letter == word[i]){
                tile.SetState(correctState);
                remaining = remaining.Remove(i,1);
                remaining = remaining.Insert(i," ");
            }
            else if(!word.Contains(tile.letter)){
                tile.SetState(incorrectState);  
            }
        }

        for(int i = 0;i< row.tiles.Length;i++){
            Tile tile = row.tiles[i];
            if(tile.state != correctState && tile.state != incorrectState){
                if(remaining.Contains(tile.letter)){
                    tile.SetState(wrongSpotState);

                    int index = remaining.IndexOf(tile.letter);
                    remaining = remaining.Remove(i,1);
                    remaining = remaining.Insert(i," ");
                }
                else{
                    tile.SetState(incorrectState);
                }
            }
        }
        
        if (HasWon(row))
        {
            Win += 1;
            if (Win > 1)
            {
                exit.SetActive(true);
            }
            enabled = false;
            newWordButton.SetActive(true);
        }

        rowIndex++;
        columnIndex = 0;
        if (rowIndex >= rows.Length){
            enabled = false;
            tryAgainButton.SetActive(true);
        }
    }
    private void ClearBoard(){
        for(int row = 0; row < rows.Length; row++){
            for(int col = 0;col < rows[row].tiles.Length; col++){
                rows[row].tiles[col].SetLetter('\0');
                rows[row].tiles[col].SetState(emptyState);
            }
        }
        rowIndex = 0;
        columnIndex = 0;
    }
    
    private bool HasWon(Row row){
        for(int i = 0;i< row.tiles.Length;i++){
            if (row.tiles[i].state != correctState ) {
                return false;
            }
        }

        return true;
    }
    
    public void ExitGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Replace "MainMenu" with the name of your main menu scene
    }
}


