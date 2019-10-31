package sample;

import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import opennlp.tools.chunker.ChunkSample;
import opennlp.tools.chunker.Chunker;
import opennlp.tools.tokenize.SimpleTokenizer;
import opennlp.tools.tokenize.Tokenizer;

public class Controller {

    @FXML
    private TextArea txtInput;

    @FXML
    private void BtnHi_Action() {
        String[] t = SimpleTokenizer.INSTANCE.tokenize(txtInput.getText());
        txtInput.setText("");
        for (String s: t) {
            txtInput.appendText(s + '\n');
        }
    }
}
