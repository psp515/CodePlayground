package app;

import java.io.IOException;
import java.util.Arrays;
import java.util.List;

public class CrawlerApp {

    public static final String SCRAPER_API_KEY = "cdfbc26068a45d13032b1fe920e6c6ee";

    private static final List<String> TOPICS = List.of("Agent Cooper", "Sherlock", "Poirot", "Detective Monk");


    public static void main(String[] args) throws IOException, InterruptedException {
        PhotoCrawler photoCrawler = new PhotoCrawler();
        photoCrawler.resetLibrary();
        photoCrawler.downloadPhotoExamples();
        photoCrawler.downloadPhotosForQuery(TOPICS.get(0));
        photoCrawler.downloadPhotosForMultipleQueries(TOPICS);
    }
}