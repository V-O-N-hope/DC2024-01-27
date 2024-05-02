package by.bsuir.romankokarev.impl.dto;

import lombok.Getter;
import lombok.Setter;

@Setter
@Getter
public class UserRequestTo {
    private long id;
    private String login;
    private String password;
    private String firstname;
    private String lastname;
}
