package by.bsuir.poit.dc.cassandra.api.exceptions;

/**
 * @author Paval Shlyk
 * @since 31/01/2024
 */

public class ResourceNotFoundException extends ResourceException {
    public ResourceNotFoundException(String message, int code) {
	super(message, code);
    }

}
